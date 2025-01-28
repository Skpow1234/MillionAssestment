import type { NextApiRequest, NextApiResponse } from 'next';

interface Property {
    id: string;
    name: string;
    address: string;
    price: number;
    idOwner: string;
    imageUrl: string;
}

// Example in-memory data (for demonstration purposes)
const properties: Property[] = [
    {
        id: '1',
        name: 'House 1',
        address: '123 Main St',
        price: 500000,
        idOwner: 'Owner1',
        imageUrl: 'http://example.com/house1.jpg',
    },
    {
        id: '2',
        name: 'House 2',
        address: '456 Elm St',
        price: 750000,
        idOwner: 'Owner2',
        imageUrl: 'http://example.com/house2.jpg',
    },
];

export default function handler(req: NextApiRequest, res: NextApiResponse) {
    const { method, query } = req;

    switch (method) {
        case 'GET': {
            const { id } = query;

            if (id) {
                // Fetch a single property by ID
                const property = properties.find((p) => p.id === id);
                if (!property) {
                    return res.status(404).json({ message: 'Property not found' });
                }
                return res.status(200).json(property);
            }

            // Fetch all properties
            return res.status(200).json(properties);
        }
        case 'POST': {
            const newProperty = req.body as Property;
            if (!newProperty) {
                return res.status(400).json({ message: 'Invalid property data' });
            }

            properties.push(newProperty); // Add new property to the list
            return res.status(201).json(newProperty);
        }
        default:
            res.setHeader('Allow', ['GET', 'POST']);
            return res.status(405).json({ message: `Method ${method} not allowed` });
    }
}
