# TCS User API - Endpoints Documentation

## Base URL
```
https://localhost:<port>/api/users
```

## Endpoints

### 1. Get All Users
**Endpoint:** `GET /api/users`

**Description:** Retrieve all users from the database

**Response (200 OK):**
```json
[
  {
	"id": 1,
	"name": "John Doe",
	"age": 30,
	"city": "New York",
	"state": "NY",
	"pincode": "10001",
	"createdAt": "2024-12-05T10:30:00Z",
	"updatedAt": null
  }
]
```

**Error Response (500):**
```json
{
  "message": "An error occurred while fetching users",
  "error": "Error details here"
}
```

---

### 2. Get User by ID
**Endpoint:** `GET /api/users/{id}`

**Description:** Retrieve a specific user by their ID

**Parameters:**
- `id` (int, required): User ID (must be > 0)

**Response (200 OK):**
```json
{
  "id": 1,
  "name": "John Doe",
  "age": 30,
  "city": "New York",
  "state": "NY",
  "pincode": "10001",
  "createdAt": "2024-12-05T10:30:00Z",
  "updatedAt": null
}
```

**Error Responses:**
- **404 Not Found:** User with the specified ID does not exist
- **400 Bad Request:** Invalid user ID (<=0)
- **500 Internal Server Error:** Server error

---

### 3. Create User
**Endpoint:** `POST /api/users`

**Description:** Create a new user

**Request Body:**
```json
{
  "name": "Jane Smith",
  "age": 28,
  "city": "Los Angeles",
  "state": "CA",
  "pincode": "90001"
}
```

**Request Validation Rules:**
- `name`: Required, 2-100 characters
- `age`: Required, 0-120
- `city`: Required
- `state`: Required
- `pincode`: Required, 4-10 characters

**Response (201 Created):**
```json
{
  "id": 2,
  "name": "Jane Smith",
  "age": 28,
  "city": "Los Angeles",
  "state": "CA",
  "pincode": "90001",
  "createdAt": "2024-12-05T10:35:00Z",
  "updatedAt": null
}
```

**Error Responses:**
- **400 Bad Request:** Invalid data or validation error
- **500 Internal Server Error:** Server error

---

### 4. Update User
**Endpoint:** `PUT /api/users/{id}`

**Description:** Update an existing user

**Parameters:**
- `id` (int, required): User ID (must be > 0)

**Request Body:**
```json
{
  "name": "Jane Doe",
  "age": 29,
  "city": "San Francisco",
  "state": "CA",
  "pincode": "94102"
}
```

**Response (200 OK):**
```json
{
  "id": 1,
  "name": "Jane Doe",
  "age": 29,
  "city": "San Francisco",
  "state": "CA",
  "pincode": "94102",
  "createdAt": "2024-12-05T10:30:00Z",
  "updatedAt": "2024-12-05T10:40:00Z"
}
```

**Error Responses:**
- **404 Not Found:** User with the specified ID does not exist
- **400 Bad Request:** Invalid user ID or data
- **500 Internal Server Error:** Server error

---

### 5. Delete User
**Endpoint:** `DELETE /api/users/{id}`

**Description:** Delete a user by their ID

**Parameters:**
- `id` (int, required): User ID (must be > 0)

**Response (200 OK):**
```json
{
  "message": "User with ID 1 deleted successfully"
}
```

**Error Responses:**
- **404 Not Found:** User with the specified ID does not exist
- **400 Bad Request:** Invalid user ID (<=0)
- **500 Internal Server Error:** Server error

---

## cURL Examples

### Get All Users
```bash
curl -X GET "https://localhost:<port>/api/users" \
  -H "Content-Type: application/json"
```

### Get User by ID
```bash
curl -X GET "https://localhost:<port>/api/users/1" \
  -H "Content-Type: application/json"
```

### Create User
```bash
curl -X POST "https://localhost:<port>/api/users" \
  -H "Content-Type: application/json" \
  -d '{
	"name": "John Doe",
	"age": 30,
	"city": "New York",
	"state": "NY",
	"pincode": "10001"
  }'
```

### Update User
```bash
curl -X PUT "https://localhost:<port>/api/users/1" \
  -H "Content-Type: application/json" \
  -d '{
	"name": "John Smith",
	"age": 31,
	"city": "Boston",
	"state": "MA",
	"pincode": "02101"
  }'
```

### Delete User
```bash
curl -X DELETE "https://localhost:<port>/api/users/1" \
  -H "Content-Type: application/json"
```

---

## Status Codes Summary

| Code | Status | Description |
|------|--------|-------------|
| 200 | OK | Request successful |
| 201 | Created | Resource created successfully |
| 400 | Bad Request | Invalid request data or parameters |
| 404 | Not Found | Resource not found |
| 500 | Internal Server Error | Server error occurred |

---

## Features

✅ **Full CRUD Operations** - Create, Read, Update, Delete users
✅ **Comprehensive Logging** - All operations are logged
✅ **Error Handling** - Proper HTTP status codes and error messages
✅ **Input Validation** - All fields are validated
✅ **Database Persistence** - Data stored in SQL Server LocalDB
✅ **Swagger Documentation** - Auto-generated API docs available at `/swagger`
✅ **Async Operations** - All database operations are async

---

## Testing with Swagger UI

1. Run the application
2. Open browser: `https://localhost:<port>/swagger`
3. Test all endpoints directly from the Swagger UI

