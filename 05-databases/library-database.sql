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


-- Loans with book titles
SELECT l.id, books.title, l.loan_date
FROM loans l
INNER JOIN books ON l.book_id = books.id;

-- Loans with member names
SELECT l.id, members.name
FROM loans l
INNER JOIN members ON l.member_id = members.id;

-- Books and their borrowers
SELECT books.title, members.name
FROM loans l
INNER JOIN books ON l.book_id = books.id
INNER JOIN members ON l.member_id = members.id;

-- All books with loan IDs
SELECT b.title, l.id
FROM books b
LEFT JOIN loans l ON b.id = l.book_id;

-- Only loaned books
SELECT b.title, l.id
FROM books b
INNER JOIN loans l ON b.id = l.book_id;

-- Total number of books
SELECT COUNT(*) FROM books;

-- Number of books by genre
SELECT genre, COUNT(*) 
FROM books
GROUP BY genre;

-- Number of loans by member ID
SELECT l.member_id, COUNT(*)
FROM loans l
GROUP BY l.member_id;

-- Number of loans by member name
SELECT m.name, COUNT(l.id)
FROM loans l
INNER JOIN members m ON l.member_id = m.id
GROUP BY m.name;

-- Active loans by member
SELECT m.name, COUNT(*) 
FROM loans l
INNER JOIN members m ON l.member_id = m.id
WHERE l.return_date IS NULL
GROUP BY m.name, m.id;

-- Members with 2 or more loans
SELECT m.name, COUNT(*)
FROM loans l
INNER JOIN members m ON l.member_id = m.id
GROUP BY m.name, m.id
HAVING COUNT(*) >= 2;

-- Top 3 most loaned book IDs
SELECT l.book_id, COUNT(*) AS loan_count
FROM loans l
GROUP BY l.book_id
ORDER BY loan_count DESC
LIMIT 3;

-- Top 3 most loaned books
SELECT b.title, COUNT(*) AS loan_count
FROM loans l
INNER JOIN books b ON l.book_id = b.id
GROUP BY l.book_id
ORDER BY loan_count DESC
LIMIT 3;

-- Loans for unavailable books
SELECT * FROM loans l
WHERE l.book_id IN (
    SELECT b.id 
    FROM books b 
    WHERE b.is_available = FALSE
);

-- Loans for SciFi books
SELECT * FROM loans l
WHERE l.book_id IN (
    SELECT b.id 
    FROM books b 
    WHERE b.genre = 'SciFi'
);

-- Intentional error: table "b" does not exist
SELECT b.title 
FROM books b
WHERE b.id > (
    SELECT AVG(b.id) 
    FROM books
);