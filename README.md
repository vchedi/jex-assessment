# JEX Backend Assessment

Public repository containing a technical assessment for JEX.

## Repository structure
- `01. Database/` – Database schema and seed scripts
- `02. Code/` – Application source code
- `03. Postman Collections/` – Postman collection for API testing

## Tech stack
- .NET
- EF Core
- SQL Server

### Database
1. Create an empty SQL Server database (for example: `Jex`)
2. Execute `database/schema.sql`
3. Execute `database/seed.sql`

### Application
1. Open the solution in Visual Studio
2. Configure the connection string locally in `appsettings.Development.json`
3. Run the application (F5)

### API testing (optional)
- Import the Postman collection from the `postman` folder
- Requests without a prefix are related to User Story 1
- User story 2 and 3 are prefixed with "US2 - /US3 - "

## Notes / assumptions

- **Configuration / secrets**
  - The repository does not have the connectionstring included.
  - Change the connectionstring in `appsettings.Development.json` to make the project run.
  - Normally this would be stored somewhere else for example Azure Keyvault.

- **Swagger / documentation**
  - XML comments were left out for this assesment.
  - Normally this would be configured so that swagger would have the detailed information.

- **Vacancy identification**
  - Vacancies would normally have an internal numeric identifier.
  - For this assignment the `Guid` ID were used

## License
MIT
