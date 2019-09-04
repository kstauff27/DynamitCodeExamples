/* Note: These queries are all listed in the same file for ease of reading. The SELECT statements should all be executed separately. 
   The CREATE TABLE and INSERT statements should be run together, and it assumes that the database has already been created. */

/* TVPrices Table Creation */
CREATE TABLE TVPrices (
	TVModel VARCHAR(255),
	DateUpdated DATETIME,
	Price MONEY
);

INSERT INTO TVPrices (TVModel, DateUpdated, Price) VALUES
('Samsung v100','2012-02-23 23:00:00',549.99),
('Sony x300','2012-05-22 00:00:00',359.99),
('Samsung v100','2013-01-22 10:20:00',359.99),
('Samsung v100','2013-02-22 00:00:00',399.99),
('Sony x300','2013-02-23 00:00:00',329.99),
('Samsung v100','2013-02-23 21:30:00',639.99),
('Sony x300','2013-05-23 22:00:00',629.99),
('Sony x300','2013-05-23 22:00:00',629.99),
('Samsung z100','2013-06-11 22:00:00',879.99);


/* Read and list the table */
SELECT * FROM TVPrices;

/* Read and list the table sorted by date updated */
SELECT * FROM TVPrices
ORDER BY DateUpdated DESC;


/* Return a unique list of TV Models and the most recent price associated with each model
		Bonus: repeat the last item with a single query */
SELECT a.TVModel, b.Price FROM 
	(SELECT TVModel, MAX(DateUpdated) AS DateUpdated FROM TVPrices GROUP BY TVModel) AS a
	JOIN 
	(SELECT DISTINCT TVModel, DateUpdated, Price FROM TVPrices) AS b
	ON a.TVModel = b.TVModel AND a.DateUpdated = b.DateUpdated;