# VulnLab - SQL Injection Demo

VulnLab is an educational web application designed to demonstrate SQL Injection vulnerabilities and how to mitigate them. This project includes both a vulnerable version and a secure version, allowing users to learn the impact of SQL Injection attacks and the best practices to prevent them.

## Features

- **SQL Injection Vulnerability**: The vulnerable version demonstrates how attackers can exploit weak code to execute malicious SQL queries.
- **SQL Injection Protection**: The secure version of the application uses parameterized queries to prevent SQL Injection attacks.
- **Login Interface**: A login page where users can enter credentials (username and password) to authenticate themselves.
- **Real-Time Attack Demonstration**: Shows the effects of SQL Injection in real-time without compromising actual server security.
- **Attack Logs**: If the protection is enabled, any detected SQL Injection attempts are logged for review.

## Lessons Learned

- **Understanding SQL Injection**: By simulating the attack, we gain insight into the mechanics of SQL Injection and its potential risks.
- **Secure Coding Practices**: By using parameterized queries and ORM frameworks, we can ensure that our code is safe from SQL Injection attacks.
- **Importance of Input Validation**: Preventing unsanitized user input from being used in SQL queries is crucial for maintaining application security.
