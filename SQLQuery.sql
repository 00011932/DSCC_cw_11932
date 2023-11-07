USE [dscc-db-11932];
-- Inserting records into the 'Items' table
INSERT INTO Items (Name, Description, Price, Quantity, CreatedAt, Category)
VALUES
    ('Item 1', 'Description for Item 1', 19.99, 100, '2023-01-01', 0),
    ('Item 2', 'Description for Item 2', 29.99, 50, '2023-01-02', 1),
	('Item 3', 'Description for Item 3', 89.99, 100, '2023-01-01', 0),
    ('Item 4', 'Description for Item 4', 35.25, 50, '2023-01-02', 2),
	('Item 5', 'Description for Item 5', 19.99, 100, '2023-01-01', 0),
    ('Item 6', 'Description for Item 6', 29.60, 50, '2023-01-02', 2),
	('Item 7', 'Description for Item 7', 84.45, 100, '2023-01-01', 0),
    ('Item 8', 'Description for Item 8', 27.77, 50, '2023-01-02', 1),
	('Item 9', 'Description for Item 9', 19.99, 100, '2023-01-01', 0),
    ('Item 10', 'Description for Item 10', 29.99, 50, '2023-01-02', 1),
	('Item 11', 'Description for Item 1', 19.99, 100, '2023-01-01', 0),
    ('Item 12', 'Description for Item 2', 29.99, 50, '2023-01-02', 2),
	('Item 13', 'Description for Item 1', 19.99, 100, '2023-01-01', 0),
    ('Item 14', 'Description for Item 2', 84.99, 50, '2023-01-02', 1),
	('Item 15', 'Description for Item 3', 19.99, 100, '2023-01-01', 0),
    ('Item 16', 'Description for Item 4', 90.25, 50, '2023-01-02', 2),
	('Item 17', 'Description for Item 5', 19.99, 100, '2023-01-01', 0),
    ('Item 6', 'Description for Item 6', 29.60, 50, '2023-01-02', 2),
	('Item 7', 'Description for Item 7', 19.45, 100, '2023-01-01', 0),
    ('Item 8', 'Description for Item 8', 27.77, 50, '2023-01-02', 1),
	('Item 9', 'Description for Item 1', 19.99, 100, '2023-01-01', 0),
    ('Item 10', 'Description for Item 2', 29.99, 50, '2023-01-02', 1),
	('Item 11', 'Description for Item 1', 19.99, 100, '2023-01-01', 0),
    ('Item 25', 'Description for Item 2', 29.99, 50, '2023-01-02', 2)


-- Inseriting Data For Transactions table
INSERT INTO Transactions(ItemId, TransactionDate, SoldItemsCount)
VALUES
    (1, '2023-01-03', 5),
    (2, '2023-01-04', 10),
	(3, '2023-01-03', 5),
    (4, '2023-01-04', 10),
	(5, '2023-01-03', 5),
    (6, '2023-01-04', 10),
	(7, '2023-01-03', 5),
    (8, '2023-01-04', 10),
	(9, '2023-01-03', 5),
    (10, '2023-01-04', 10),
	(1, '2023-01-03', 5),
    (2, '2023-01-04', 10),
	(3, '2023-01-03', 5),
    (4, '2023-01-04', 10),
	(5, '2023-01-03', 5),
    (6, '2023-01-04', 10),
	(7, '2023-01-03', 5),
    (2, '2023-01-04', 10),
	(5, '2023-01-03', 5),
    (6, '2023-01-04', 10)