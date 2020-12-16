using System;

public class Table
{
	public int NumTable;
	public Materiel Content;
	public Client ClientPresent;
	public Client ClientDish;
	public Dish PresentDish;
	public int PresentMenu;
	public int ClientMenuSection;
	public int ProgressMeal;

	public Table(int NumTable, int Place)
	{
	}

	public void	AddClient(Client C_Add)
    {

    }
	public void RemoveClient(Client C_Remove)
    {

    }
	public void AddContent(Materiel MaterielAdd)
    {

    }
	public void RemoveContent(Materiel MaterielRemove)
    {

    }
	public void AddDish(Dish DishAdd)
    {

    }
	public void ReserveDish(int IDDish, int IDClient)
    {

    }
	public void preventServer(string message)
    {

    }
	public void preventCommis(string message)
    {

    }
	public void ProgressMeal()
    {

    }
}