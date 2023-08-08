# ☎ PhoneBook - API

This is a simple API for managing phone contacts in a phone book. It allows you to add, retrieve, update, and delete contacts.

## Table of Contents 📰

- Introduction
- Technologies Used
- Getting Started
- Endpoints
  - Add Contact
  - Get All Contacts
  - Get Contact by ID
  - Update Contact
  - Delete Contact
- License

## Introduction 🎁

The PhoneBook API provides a straightforward way to manage phone contacts. You can add, retrieve, update, and delete contacts using the provided endpoints.

## Technologies Used ⚙

- ASP.NET Core
- Entity Framework Core
- AutoMapper

Getting Started

1. Clone the repository: `git clone https://github.com/yourusername/phonebook-api.git`
2. Navigate to the project directory: `cd phonebook-api`
3. Restore packages: `dotnet restore`
4. Build the project: `dotnet build`
5. Run the API: `dotnet run`

## Endpoints

### Add Contact ☑

Add a new contact to the phone book.

- URL: /phoneBook
- Method: POST
- Request Body:

```json
{
  "phoneNumber": "1234567890",
  "alternativePhone": "9876543210",
  "description": "Work",
  "contactName": "John Doe"
}
```
- "alternativePhone" is optional

### Get All Contacts 🛄

Retrieve a list of all contacts in the phone book.

- URL: /phoneBook
- Method: GET
- Query Parameters:
  - skip (optional): Number of contacts to skip (default: 0).
  - take (optional): Number of contacts to take (default: 10).

### Get Contact by ID 🛅

Retrieve a contact by its ID.

- URL: /phoneBook/{id}
- Method: GET
- URL Parameters:
  - id: ID of the contact to retrieve.

### Update Contact 🔄

Update an existing contact.

- URL: /phoneBook/{id}
- Method: PATCH
- URL Parameters:
  - id: ID of the contact to update.
- Request Body:

```json
{
  "phoneNumber": "9876543210",
  "alternativePhone": "1234567890",
  "description": "Personal",
  "contactName": "Jane Smith"
}
```

### Delete Contact 🗑

Delete a contact from the phone book.

- URL: /phoneBook/{id}
- Method: DELETE
- URL Parameters:
  - id: ID of the contact to delete.

## License 📝

This project is licensed under the MIT License. Feel free to use and modify the code as per the terms of the license.
