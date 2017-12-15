#include "pasajero.h"

#include <random>

//constructor del pasajero
pasajero::pasajero(int id_)
{
    this->id = id_;
    this->siguiente = nullptr;
    std::random_device rd;
    //generar cantidad de maletas
    std::uniform_int_distribution<int> m(1,4);//rango
    this->maletas = m(rd);
    //generar documentos
    std::uniform_int_distribution<int> d(1,10);//rango
    this->documentos = d(rd);
    //generar turnos para registro
    std::uniform_int_distribution<int> t(1,3);
    this->turnos = t(rd);
}

//constructor del desabordaje
desabordaje::desabordaje()
{
    this->primero = nullptr;
    this->ultimo = nullptr;
    this->cont = 1;
}

void desabordaje::push()
{
    //generar nuevo pasajero con el id correlativo actual
    pasajero *nuevo = new pasajero(this->cont);
    if(this->primero == nullptr)
    {
        this->primero = nuevo;
        this->ultimo = nuevo;
        this->cont++;
    }
    else
    {
        this->ultimo->siguiente = nuevo;
        this->ultimo = nuevo;
        this->cont++;
    }
}

pasajero *desabordaje::pop()
{
    if(this->primero != nullptr)
    {
        pasajero *ret = this->primero;
        this->primero = ret->siguiente;
        return ret;
    }
    else return nullptr;
}
