# 🏥 Hospital Management System – ASP.NET Core MVC

A structured Hospital Management System built using **ASP.NET Core MVC** and **Entity Framework Core**.
The project is designed based on **client requirements** to manage doctors, clinics, patients, appointments, and employees with full CRUD operations.

---

## 📌 Project Idea

The system allows the hospital to:

* Manage doctors, clinics, and employees
* Schedule and manage appointments between doctors and patients
* Maintain relationships between different entities
* Provide an easy-to-use interface using Bootstrap 5

---

## 🎯 Client Requirements

The client requested a system that allows:

* Adding, editing, viewing, and deleting doctors, clinics, patients, and appointments
* Assigning each doctor to a specific clinic
* Linking patients with doctors and appointments
* Displaying related information clearly (e.g., clinic name for each doctor)
* Maintaining database relationships using foreign keys

---

## 🛠 Core CRUD Operations

### **1. Create**

* Add doctors, clinics, patients, appointments
* Assign doctors to clinics, and patients to appointments

### **2. Read**

* Display lists of doctors, clinics, patients, and appointments
* Show related data (e.g., doctor name, clinic name, appointment date)

### **3. Update**

* Modify any entity’s information while keeping relationships intact

### **4. Delete**

* Remove doctors, clinics, patients, or appointments
* Prevent breaking relationships (foreign key constraints)

---

## 🔗 Database Relationships

### **1. Doctor ↔ Clinic (One-to-Many)**

* Each doctor belongs to one clinic
* One clinic can have multiple doctors

```text
Clinic 1 ────< Doctor Many
```

### **2. Doctor ↔ Patient (One-to-Many)**

* A doctor can have multiple patients
* Each patient can be assigned to one doctor

```text
Doctor 1 ────< Patient Many
```

### **3. Doctor ↔ Appointment (One-to-Many)**

* Each doctor can have multiple appointments
* Each appointment is linked to one doctor

```text
Doctor 1 ────< Appointment Many
```

### **4. Clinic ↔ Appointment (One-to-Many)**

* Each appointment belongs to a clinic (through the doctor)
* Each clinic can have multiple appointments

```text
Clinic 1 ────< Appointment Many
```

---

## 📁 Project Structure Overview

* **Models** – represent database tables: Doctor, Clinic, Patient, Appointment
* **Controllers** – handle CRUD logic for each entity
* **Views** – Razor views using Bootstrap 5 for forms and tables
* **DbContext** – connects the application to SQL Server and manages relationships

---

## 🚀 How to Run the Project

1. Set your SQL Server connection string in `appsettings.json`
2. Run EF Core migrations:

```bash
Add-Migration InitialCreate
Update-Database
```

3. Run the project in Visual Studio

---

## 👤 Developer

**Mohamed Araby**



Do you want me to do that?
