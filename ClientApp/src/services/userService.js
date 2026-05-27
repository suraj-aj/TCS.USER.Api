import axios from 'axios';

const API_BASE_URL = import.meta.env.VITE_API_URL || 'https://localhost:5001/api';

const apiClient = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

// Add token to request headers if available
apiClient.interceptors.request.use((config) => {
  const token = localStorage.getItem('authToken');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export const userService = {
  // Get all users
  getAllUsers: () => apiClient.get('/users'),

  // Get user by ID
  getUserById: (id) => apiClient.get(`/users/${id}`),

  // Create new user
  createUser: (userData) => apiClient.post('/users', userData),

  // Update user
  updateUser: (id, userData) => apiClient.put(`/users/${id}`, userData),

  // Delete user
  deleteUser: (id) => apiClient.delete(`/users/${id}`),
};

export default apiClient;
