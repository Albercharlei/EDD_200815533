using System;

public class mo
{
    public int x;//tamaño de coordenadas de x
	public mo()//tamaño de coordenadas de y
	{

	}
}

class unit
{
    private String id;//nombre de la unidad
    public int x;//coordenada en x
    public int y;//coordenada en y
    private int nivel;//coordenada en z
    //punteros en x
    public unit izq;
    public unit der;
    //punteros en y
    public unit arriba;
    public unit abajo;
    //punteros en z
    public unit sup;
    public unit inf;

    public unit(String id_, int x_, int y_)
    {
        id = id_;
        x = x_;
        y = y_;
        if (id_.Equals("Neosatelite")) nivel = 4;
    }
}