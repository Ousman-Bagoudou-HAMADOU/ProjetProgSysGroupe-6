#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------


#------------------------------------------------------------
# Table: Restaurant
#------------------------------------------------------------

CREATE TABLE Restaurant(
        ID_Restaurant Int  Auto_increment  NOT NULL ,
        Nom_Restau    Varchar (50) NOT NULL ,
        Lieu_Restau   Varchar (50) NOT NULL
	,CONSTRAINT Restaurant_PK PRIMARY KEY (ID_Restaurant)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Categorie
#------------------------------------------------------------

CREATE TABLE Categorie(
        ID_Categorie  Int  Auto_increment  NOT NULL ,
        Nom_Categorie Varchar (50) NOT NULL ,
        ID_Restaurant Int NOT NULL
	,CONSTRAINT Categorie_PK PRIMARY KEY (ID_Categorie)

	,CONSTRAINT Categorie_Restaurant_FK FOREIGN KEY (ID_Restaurant) REFERENCES Restaurant(ID_Restaurant)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Recette
#------------------------------------------------------------

CREATE TABLE Recette(
        ID_Recette     Int  Auto_increment  NOT NULL ,
        Titre_Recette  Varchar (50) NOT NULL ,
        Nbre_Personne  Int NOT NULL ,
        TmpPrepa       Int NOT NULL ,
        TmpCuisson     Int NOT NULL ,
        TmpRepos       Int NOT NULL ,
        Ingredient     Varchar (50) NOT NULL ,
        Accompagnement Varchar (50) NOT NULL ,
        ID_Categorie   Int NOT NULL
	,CONSTRAINT Recette_PK PRIMARY KEY (ID_Recette)

	,CONSTRAINT Recette_Categorie_FK FOREIGN KEY (ID_Categorie) REFERENCES Categorie(ID_Categorie)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Stockage
#------------------------------------------------------------

CREATE TABLE Stockage(
        ID_Stockage   Int  Auto_increment  NOT NULL ,
        Nom_Stockage  Varchar (50) NOT NULL ,
        ID_Restaurant Int NOT NULL
	,CONSTRAINT Stockage_PK PRIMARY KEY (ID_Stockage)

	,CONSTRAINT Stockage_Restaurant_FK FOREIGN KEY (ID_Restaurant) REFERENCES Restaurant(ID_Restaurant)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Denrée 
#------------------------------------------------------------

CREATE TABLE Denree(
        ID_Denree   Int  Auto_increment  NOT NULL ,
        Nom_Denree  Varchar (50) NOT NULL ,
        Qte         Int NOT NULL ,
        ID_Stockage Int NOT NULL
	,CONSTRAINT Denree_PK PRIMARY KEY (ID_Denree)

	,CONSTRAINT Denree_Stockage_FK FOREIGN KEY (ID_Stockage) REFERENCES Stockage(ID_Stockage)
)ENGINE=InnoDB;

