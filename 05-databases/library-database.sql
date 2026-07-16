CREATE DATABASE Library;

USE Library;
CREATE TABLE members
(
	id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    registered_date DATE
);

CREATE TABLE books
(
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    author VARCHAR(255) NOT NULL,
    genre VARCHAR(100),
    is_available BOOLEAN DEFAULT TRUE
);

CREATE TABLE loans
(
    id INT AUTO_INCREMENT PRIMARY KEY,
    book_id INT NOT NULL,
    member_id INT NOT NULL,
    loan_date DATE NOT NULL,
    return_date DATE,
    FOREIGN KEY (book_id) REFERENCES books(id),
    FOREIGN KEY (member_id) REFERENCES members(id)
);

INSERT INTO members(name, registered_date) 
VALUES 
	('Anna Schmidt', CURRENT_TIMESTAMP),
    ('Marco Rossi', CURRENT_TIMESTAMP),
    ('Yuki Tanaka', CURRENT_TIMESTAMP),
    ('David Miller', CURRENT_TIMESTAMP);

INSERT INTO books(title, author, genre) 
VALUES 
	('Clean Code','Robert Martin','Programming'),
    ('The Pragmatic Programmer','Andrew Hunt','Programming'),
    ('Dune','Frank Herbert','SciFi'),
    ('1984','George Orwell','Dystopia'),
    ('Clean Architecture','Robert Martin','Programming'),
    ('Foundation','Isaac Asimov','SciFi');

INSERT INTO `loans`(`book_id`, `member_id`, `loan_date`) 
VALUES 
	(1,1,CURRENT_TIMESTAMP),
    (2,1, CURRENT_TIMESTAMP),
    (3,1,CURRENT_TIMESTAMP),
    (5,2,CURRENT_TIMESTAMP);