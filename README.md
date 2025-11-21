# PROG6212 POE Part 3 – Lecturer Claim System  
**Student Number:** ST10440651  
**Group:** 1  
**GitHub:** https://github.com/VCCT-PROG6212-2025-G1/StudentClaimsSystem  

### Project Overview
A WPF desktop application (.NET 8) for lecturers to submit extra hours claims with supporting documents.  
Uses MVVM pattern, Entity Framework Core (SQLite), file uploads, LiveCharts, and session-like navigation control.

### Key Features Implemented
- Add modules and claim extra hours
- File upload for supporting documents (saved in `/Documents`)
- Max 180 hours validation with error message
- Dashboard with chart and claim list
- Data saved permanently using EF Core + SQLite (`claims.db`)
- Navigation control (cannot access pages directly – acts as sessions)
- No login required (allowed per 28 Oct lecturer meeting)
- No APIs used (optional – safe route taken)

### How to Run (30 seconds)
1. Open in Visual Studio 2022/2025
2. Open **Package Manager Console**
3. Run these two commands:
   ```powershell
   Add-Migration InitialCreate
   Update-Database
