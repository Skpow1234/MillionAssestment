import { useRouter } from 'next/router';
import React, { useEffect, useState } from 'react';
import axios from '../../utils/apiClient';
import { Property } from '../../types/Property';

const PropertyDetails = () => {
    const [property, setProperty] = useState<Property | null>(null);
    const router = useRouter();
    const { id } = router.query;

    useEffect(() => {
        if (id) {
            const fetchProperty = async () => {
                const response = await axios.get(`/properties/${id}`);
                setProperty(response.data);
            };

            fetchProperty();
        }
    }, [id]);

    if (!property) {
        return <p>Loading...</p>;
    }

    return (
        <div>
            <h1>{property.name}</h1>
            <p>{property.address}</p>
            <p>Price: ${property.price}</p>
            <img src={property.imageUrl} alt={property.name} width="300" />
        </div>
    );
};

export default PropertyDetails;
