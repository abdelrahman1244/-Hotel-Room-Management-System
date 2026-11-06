# 🏨 Hotel Room Management System

A web application designed to help hotel front-desk staff manage rooms, customers, and bookings in one place.

Built using **ASP.NET Core MVC, C#, Entity Framework Core, and SQL Server**.

> Developed as a hands-on project after completing the Web Development using .NET (144 hrs) program at the Information Technology Institute (ITI).

## ✨ Features

### Rooms Management
- View all rooms with room number, type, and price per night.
- Add, edit, and delete rooms.
- View room details and availability status.
- Confirmation before deleting a room.

### Customers Management
- View all registered customers with their profile pictures.
- Register new customers with full name, phone number, and profile picture.
- View customer details and booking history.
- Edit customer information and update profile pictures.
- Delete customers with a confirmation step.

### Bookings Management
- View all bookings and their details.
- Create bookings by selecting a room and customer.
- Set check-in and check-out dates.
- Edit and delete existing bookings.
- Validate booking dates and prevent overlapping reservations for the same room.

### General Features
- Front-desk dashboard as the home page.
- Input validation before saving data.
- Confirmation pages before deletion.
- Relationship management between rooms, customers, and bookings.

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Programming Language | C# |
| Framework | ASP.NET Core MVC |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Architecture | Model-View-Controller (MVC) |
| Frontend | HTML, CSS, Bootstrap, JavaScript |

## 🗄️ Data Model

The application is built around three main entities:

**Room**
- Id
- RoomNumber
- Type
- PricePerNight
- Status

**Customer**
- Id
- FullName
- Phone
- ProfilePicture

**Booking**
- Id
- RoomId
- CustomerId
- CheckIn
- CheckOut

### Relationships
- One customer can have multiple bookings.
- One room can have multiple bookings over time.
- Each booking belongs to one customer and one room.

## 🚀 Getting Started

### Prerequisites
- .NET SDK compatible with the project target framework.
- SQL Server or SQL Server LocalDB.
- Visual Studio 2022 or later.

### Installation

1. Clone the repository:

```bash
git clone https://github.com/abdelrahman1244/-Hotel-Room-Management-System.git
```

2. Open the solution file in Visual Studio.

3. Configure your SQL Server connection string locally using the connection string key expected by the application.

4. Apply the database migrations:

```bash
dotnet ef database update
```

5. Run the application:

```bash
dotnet run
```

Open the localhost URL displayed in the terminal.

## 🔮 Planned Improvements

- [ ] Add a unique constraint on room numbers.
- [ ] Implement authentication and role-based authorization using ASP.NET Core Identity.
- [ ] Add search and filtering to listing pages.
- [ ] Improve dashboard analytics and reporting.

## 👨‍💻 Author

**Abdelrahman Mohamed Abdelaziz**

Computer Science Student – October 6 University.

- **GitHub:** [abdelrahman1244](https://github.com/abdelrahman1244)
- **LinkedIn:** [Abdelrahman Mohamed](https://www.linkedin.com/in/abdelrahman-mohamed-243a02307/)

**Supervised by:** Eng. Mohamed Abdel-Latif
