# TCS User Management - React Client App

A modern React web application for managing users through the TCS.USER.Api REST API.

## Features

- 📋 View all users in a responsive table
- ➕ Create new users with validation
- 🗑️ Delete users
- 🔄 Real-time data updates
- 📱 Fully responsive design
- 🎨 Clean and modern UI

## Prerequisites

- Node.js 16+ and npm
- TCS.USER.Api running on `https://localhost:5001`

## Project Structure

```
ClientApp/
├── src/
│   ├── pages/           # Page components
│   │   ├── UserList.jsx
│   │   └── CreateUser.jsx
│   ├── services/        # API services
│   │   └── userService.js
│   ├── styles/          # CSS files
│   │   ├── UserList.css
│   │   └── CreateUser.css
│   ├── App.jsx
│   ├── App.css
│   ├── main.jsx
│   └── index.css
├── index.html
├── vite.config.js
├── package.json
└── README.md
```

## Installation

### 1. Install Dependencies

```bash
cd ClientApp
npm install
```

### 2. Environment Configuration

Create a `.env.local` file (optional, if API is on a different URL):

```env
VITE_API_URL=https://localhost:5001/api
```

## Development

Start the development server:

```bash
npm run dev
```

The application will be available at `http://localhost:3000`

### Proxy Configuration

The Vite dev server is configured to proxy API requests to `https://localhost:5001`, so API calls will work seamlessly during development.

## Build

Build for production:

```bash
npm run build
```

The production-ready files will be in the `dist/` directory.

## Preview Production Build

Preview the production build locally:

```bash
npm run preview
```

## API Integration

The app communicates with the backend API through the `userService`:

```javascript
import { userService } from '../services/userService';

// Get all users
const response = await userService.getAllUsers();

// Create user
await userService.createUser(userData);

// Delete user
await userService.deleteUser(id);
```

## Pages

### Users List (`/`)
- Displays all users in a table
- Delete functionality for each user
- Responsive design for mobile devices

### Create User (`/create`)
- Form to create a new user
- Client-side and server-side validation
- Error handling and display

## Technologies Used

- **React** - UI library
- **React Router** - Client-side routing
- **Vite** - Build tool and dev server
- **Axios** - HTTP client for API calls
- **CSS3** - Styling

## Browser Support

- Chrome (latest)
- Firefox (latest)
- Safari (latest)
- Edge (latest)

## Troubleshooting

### API Connection Issues

If you see "Failed to load users" error:
1. Ensure TCS.USER.Api is running on `https://localhost:5001`
2. Check the browser console for CORS errors
3. Verify API_BASE_URL in `src/services/userService.js`

### Build Issues

Clear node_modules and reinstall:
```bash
rm -r node_modules package-lock.json
npm install
```

## Future Enhancements

- [ ] User edit/update functionality
- [ ] Authentication and authorization
- [ ] Search and filter users
- [ ] Pagination
- [ ] Export users to CSV
- [ ] Dark mode
- [ ] Unit tests

## Contributing

1. Create a feature branch
2. Make your changes
3. Test thoroughly
4. Submit a pull request

## License

MIT

---

**Note**: Make sure the backend API is running before starting the React development server.
