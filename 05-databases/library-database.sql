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


-- === DataBase Queries === --

-- All books
SELECT * FROM books;

-- Book titles and authors
SELECT title, author FROM books;

-- Programming books
SELECT * FROM books 
WHERE genre = 'Programming';

-- Available books
SELECT * FROM books 
WHERE is_available = TRUE;

-- Active loans
SELECT * FROM loans 
WHERE return_date IS NULL;

-- Books sorted by title
SELECT * FROM books 
ORDER BY title;

-- Books by authors named Martin
SELECT * FROM books 
WHERE author LIKE '%Martin%';

-- First 3 books by title
SELECT * FROM books 
ORDER BY title 
LIMIT 3;

-- First 2 available programming books
SELECT * FROM books 
WHERE genre = 'Programming' 
  AND is_available = TRUE
ORDER BY title
LIMIT 2;


-- Marks book 3 as unavailable
UPDATE books 
SET is_available = FALSE
WHERE id = 3;

-- Returns loan 1 today
UPDATE loans 
SET return_date = CURDATE()
WHERE id = 1;

-- Shows loan 4
SELECT * FROM loans 
WHERE id = 4;

-- Deletes loan 4
DELETE FROM loans 
WHERE id = 4;

-- Intentional error: book 2 is referenced by a loan
DELETE FROM books 
WHERE id = 2;