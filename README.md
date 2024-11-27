# Vacancy Management Application

Vacancy Management System
This project implements a comprehensive Vacancy Management System designed to streamline and automate the recruitment process. The system is built using ASP.NET Core for the backend, Entity Framework Core for database management and  Angular for the frontend.

# **Project Overview**
The Vacancy Management System is a platform designed to facilitate the hiring process by enabling automated workflows for managing job vacancies, candidate applications, and assessments.

**Key Features**:
1. **Job Vacancy Management**
- Create, edit, delete, and publish job vacancies.
- Set active or inactive statuses for vacancies.
  
2. **Candidate Application Process**
- View active job vacancies.
- Submit applications through a structured form with validation.
3. **Automated Test Generation**
- Assign relevant test questions based on the vacancy.
- Provide real-time timers and sequential question navigation.
- Score tests automatically and classify results by performance.
3. **File Uploads**
- Allow candidates to upload CVs in PDF or DOCX format (max size: 5MB).
- Validate file type and size before storing.
4. **Admin Panel**
- Manage vacancies, candidates, and test questions.
- View detailed test results with color-coded performance levels.
5. **Scalable Architecture**
- Modular design supporting easy addition of features like multi-choice questions.

# **Technology Stack**
**Backend**
- Framework: ASP.NET Core
- Database ORM: Entity Framework Core
  
**Frontend**
 - Angular
   
**Database**
- MS SQL Server
  
**Version Control**
  - Git: All source code is maintained in a Git repository.

# **Functional Requirements**
1. **Job Vacancy Management**
- Add, edit, and delete job postings.
- Set deadlines and descriptions for each job.
- Manage a unique set of questions for each vacancy.

2. **Candidate Application**
- Form validation for required fields (e.g., name, email, phone number).
- View test progress with real-time feedback.
  
3. **Testing System**
- Deliver questions sequentially with no backtracking.
- Implement a timer for each question with a default limit of 1 minute.
- Automatically evaluate answers and calculate scores.
  
4. **File Upload**
- Ensure uploaded files are in PDF/DOCX format and under 5MB.
- Display a confirmation message upon successful upload.
  
5. **Result Evaluation**

- Provide color-coded results:
- Green: 75%-100% (Successful)
- Yellow: 50%-75% (Average)
- Red: 0%-50% (Unsuccessful)
  
6. **Admin Panel**
- Manage candidate data, test results, and uploaded CVs.
- Add, edit, and delete questions and answer options.
