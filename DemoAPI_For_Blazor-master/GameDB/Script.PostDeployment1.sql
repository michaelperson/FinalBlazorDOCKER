/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

EXEC RegisterUser 'admin@test.com', 'test1234='
EXEC RegisterUser 'user@test.com', 'test1234='
GO

UPDATE Users SET IsAdmin = 1 WHERE Id = 1

INSERT INTO Game (Titre, Note, DatedeSortie, Genre) 
VALUES ('Diablo 4', '3', 2023, 'Hack''n slash')

INSERT INTO Game (Titre, Note, DatedeSortie, Genre) 
VALUES ('GTA 6', '0', 2047, 'On verra')

INSERT INTO Game (Titre, Note, DatedeSortie, Genre) 
VALUES ('Modern Warfare 3', '2', 1982, 'FPS')