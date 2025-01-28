import axios from 'axios';
import { Property } from '../types/Property';

// Base API client
const apiClient = axios.create({
    baseURL: process.env.NEXT_PUBLIC_API_URL,
    headers: {
        'Content-Type': 'application/json',
    },
});

// API methods for Properties
export const PropertyApi = {
    // Fetch all properties with optional filters
    getAllProperties: async (
        name?: string,
        address?: string,
        minPrice?: number,
        maxPrice?: number
    ): Promise<Property[]> => {
        const response = await apiClient.get('/properties', {
            params: { name, address, minPrice, maxPrice },
        });
        return response.data;
    },

    // Fetch a property by ID
    getPropertyById: async (id: string): Promise<Property> => {
        const response = await apiClient.get(`/properties/${id}`);
        return response.data;
    },

    // Create a new property
    createProperty: async (newProperty: Property): Promise<Property> => {
        const response = await apiClient.post('/properties', newProperty);
        return response.data;
    },

    // Update an existing property
    updateProperty: async (id: string, updatedProperty: Property): Promise<void> => {
        await apiClient.put(`/properties/${id}`, updatedProperty);
    },

    // Delete a property by ID
    deleteProperty: async (id: string): Promise<void> => {
        await apiClient.delete(`/properties/${id}`);
    },
};

export default apiClient;
