# 🚀 ProductApi

A RESTful API built with .NET 6 for managing products. Provides basic CRUD operations with SQL Server integration and Swagger/OpenAPI documentation.

---

## 🧰 Technologies & Tools

- ⚙️ **Backend:** ASP.NET Core 6, C#
- 🗃️ **Database:** MS SQL Server
- 🧪 **Others:** Docker, Portainer, Git, Swagger, WSL, ngrok (optional for live connection testing)

---

## ✨ Features

- ✅ Create Product (POST /api/products) – Adds a new product.
- ✅ List Products (GET /api/products) – Retrieves all products.
- ✅ Get Product Details (GET /api/products/{id}) – Retrieves a specific product by ID.
- ✅ Delete Product (DELETE /api/products/{id}) – Deletes a product.
- ⚡ Layered Architecture: Controller → Service → Repository
- ⚡ Asynchronous programming (async/await)
- ⚡ Swagger API documentation
- ⚡ Global exception handling

---

## 📷 Demo / Screenshots

> You can test the API endpoints via Swagger UI.

```
📂 FirstProductProject/
├── ProductApi/
  └── ProductApi
  └── ProductApi.BusinessLayer
  └── ProductApi.DataAccessLayer
  └── ProductApi.EntityLayer
  └── .dockerignore
  └── ProductApi.sln
├── .gitignore/
├── Dockerfile/
├── LICENSE
└── README.md
```

---

## 📦 Installation & Run

Follow the steps below to clone and run this project locally.

```bash
# 1. Clone the repo
git clone https://github.com/yasinramazangok/FirstProductProject

# 2. Navigate into the directory
cd FirstProductProject

# 3. (Optional) Set up database / environment
# dotnet ef database update

# 4. Run the project
dotnet run
```

---

## 🧠 What I Learned

- Implementing layered architecture in ASP.NET Core (Controller → Service → Repository)
- Performing CRUD operations with Entity Framework Core
- Setting up Swagger for API documentation
- Using async/await for asynchronous operations
- Handling global exceptions

---

## 📌 Future Improvements

- 🔄 Add CI/CD pipeline
- 📱 Mobile responsiveness
- 🌍 Multi-language support (i18n)
- 🧪 Add unit/integration testing

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!

Feel free to Fork this repo and submit a Pull Request.

---

## 📬 Contact

**Yasin Ramazan GÖK** 

🌐 LinkedIn: [@yasinramazangok](https://linkedin.com/in/yasinramazangok/)  

📧 Email: [yasinrmzngok@gmail.com](mailto:yasinrmzngok@gmail.com) 

🐙 GitHub: [@yasinramazangok](https://github.com/yasinramazangok)

---

## 📝 License

This project is licensed under the **MIT License** – see the `LICENSE` file for details.
