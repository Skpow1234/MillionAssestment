import React, { useEffect, useState } from 'react';
import axios from '../../utils/apiClient';
import { Property } from '../../types/Property';

const PropertyList = () => {
    const [properties, setProperties] = useState<Property[]>([]);

    useEffect(() => {
        const fetchProperties = async () => {
            const response = await axios.get('/properties');
            setProperties(response.data);
        };

        fetchProperties();
    }, []);

    return (
        <div>
            <h1>Properties</h1>
            <ul>
                {properties.map((property) => (
                    <li key={property.id}>
                        <a href={`/properties/${property.id}`}>{property.name}</a>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default PropertyList;
