========================================================================
       SMART LEARNING MANAGEMENT SYSTEM (SmartLMS) - ACADEMIC PORTAL
                     JINNAH UNIVERSITY FOR WOMEN
========================================================================

SmartLMS is a modern, responsive, and role-based learning management system 
built using ASP.NET Core MVC. The platform is styled with a premium and 
attractive Purple Theme, specifically customized for the academic curriculum 
and local standards of Jinnah University for Women (JUW).

------------------------------------------------------------------------
1. PROJECT COLOR THEME & AESTHETICS
------------------------------------------------------------------------
* Brand Color Palette: Premium Purple (Deep Purple #6b21a8, Accent Purple #a855f7)
* Tinted Backgrounds: Soft violet (#faf5ff)
* Animations: Smooth rise-up entrance transitions (.animate-up) and pulse effects
* Sidebar & Cards: Dynamic hover-lift shadow animations with purple glows
* Responsive Layouts: Fluid design for desktop, tablet, and mobile browsers

------------------------------------------------------------------------
2. KEY FEATURES
------------------------------------------------------------------------

A. DYNAMIC WELCOME SCREEN & ROLE-BASED DASHBOARDS
* Teacher View: Custom metric counters for total courses, enrolled students, 
  and Rs. earnings. Includes a specialized welcome banner ("Professor Active View")
  and course creation panels. Student modules are hidden for security.
* Student View: Access to enrolled courses, course progress tracking, interactive 
  quizzes, and certificate print modules. Instructor tools are hidden for security.

B. SYSTEM-WIDE PAKISTANI RUPEES (Rs. / PKR) CURRENCY
* All dollar ($) pricing elements replaced with Pakistani Rupees (Rs.)
* Interactive Course Creation DTO validated for realistic PKR tuition ranges 
  (supporting ranges up to Rs. 200,000 with custom localized alerts)
* Teacher payout details and transactional summaries recorded in Rs. (70% split)

C. FULL COURSE CRUD OPERATIONS
* Teachers can View, Create, Update (Edit), and Delete courses dynamically
* Inline editing supports updates to Course Title, Syllabus Description, Category, 
  and price in PKR

D. ENROLLED STUDENTS REGISTRY WITH UNIQUE LMS IDs
* Teacher dashboard features a professional roster of enrolled students
* Students are identified by Jinnah University LMS Unique IDs 
  (formatted as: JUW-LMS-2024-XXXX)
* Tracks active student courses, registration email records, and progress status

E. INTERACTIVE LECTURE PLAYER & PROGRESS TRACKING
* Plays syllabus lectures in a high-fidelity video player via YouTube embeds
* Automatically tracks video watch states (e.g. marked as "Watched" or "Unopened")
* Dynamic progress bar showing the percentage of completed video lectures
* Smart Recommendation sidebar suggesting related software engineering lectures

F. 20-MCQ INTERACTIVE SOFTWARE ENGINEERING ASSESSMENTS
* Interactive quiz portal with 20 MCQs related to programming, databases, 
  and software engineering
* Real-time client-side evaluation displaying pass/fail states based on a 
  70% passing threshold (high/low priority matching)

G. LANDSCAPE PDF CERTIFICATES WITH NAME SYNC
* Graduates can view and print single-page landscape graduation certificates
* Auto-syncs student profile names directly onto the parchment paper template
* Control panel allows custom name overrides in real time prior to printing
* Official signature authority set to: "Hina Fatima" (Authorized Issuer)
* Clean print CSS removes sidebars and layouts, fitting the page on a single 
  landscape sheet when using window.print() or saving as PDF

H. INTERACTIVE PURPLE AI CHATBOT WIDGET
* Floating robot launcher in the bottom right corner opens a modern assistant window
* Interactive messaging support via clicking "Send" or pressing the "Enter" key
* Typing indicator simulation ("LMS Assistant is typing...") for natural interactions
* Smart keyword processor responding instantly to inquiries about courses, quizzes,
  payouts, instructors (Hira Sultan & Hina Fatima), and certificate generation

------------------------------------------------------------------------
3. GETTING STARTED & INSTALLATION
------------------------------------------------------------------------
Prerequisites:
* .NET SDK (Version 8.0 or newer)

Steps to Run:
1. Open a terminal in the project directory: "d:\SCD project"
2. Restore NuGet dependencies and build the application:
   dotnet build
3. Start the local development web server:
   dotnet run
4. Open your web browser and navigate to:
   http://localhost:5000/

------------------------------------------------------------------------
4. SEEDED DEMO ACCOUNTS
------------------------------------------------------------------------
Access the portal from: http://localhost:5000/Account/Login

* Instructor Account:
  Email: teacher@example.com (Prefilled under the Instructor Portal tab)
  Role: Teacher / Professor

* Student Account:
  Email: student@example.com (Prefilled under the Student Portal tab)
  Role: Student

========================================================================
             SmartLMS - Empowering Academic Excellence at JUW
========================================================================
