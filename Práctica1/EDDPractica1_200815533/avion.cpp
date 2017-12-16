#include "avion.h"

#include <random>

//constructor del avión
avion::avion()
{
    this->siguiente = nullptr;
    this->anterior = nullptr;
    this->cont = 1;//contador por defecto
    this->desabordado = 1;
    std::uniform_int_distribution<int> p(1,3);//rango
    std::random_device rd;
    this->tipo = p(rd);//generar entero aleatorio
    //generar pasajeros y mantenimiento para el avión pequeño
    if(this->tipo == 1)
    {
        this->tipostring = "Pequeño";
        std::uniform_int_distribution<int> pasajero(5,15);
        std::uniform_int_distribution<int> mantenimiento(1,3);
        this->pasajero = pasajero(rd);
        this->mantenimiento = mantenimiento(rd);
        this->desabordaje = 1;//un turno
    }
    //pasajeros y mantenimiento para avión mediano
    else if(this->tipo == 2)
    {
        this->tipostring = "Mediano";
        std::uniform_int_distribution<int> pasajero(15,25);
        std::uniform_int_distribution<int> mantenimiento(2,4);
        this->pasajero = pasajero(rd);
        this->mantenimiento = mantenimiento(rd);
        this->desabordaje = 2;//dos turnos
    }
    //pasajeros y mantenimiento para avión mediano
    else if(this->tipo == 3)
    {
        this->tipostring = "Grande";
        std::uniform_int_distribution<int> pasajero(30,40);
        std::uniform_int_distribution<int> mantenimiento(3,6);
        this->pasajero = pasajero(rd);
        this->mantenimiento = mantenimiento(rd);
        this->desabordaje = 3;//tres turnos
    }
}

pista::pista()
{
    this->primero = nullptr;
    this->ultimo = nullptr;
}

//insertar elementos en la pista
void pista::push()
{
    avion *nuevo = new avion();//generar nuevo avión

    if(this->primero == nullptr)
    {
        this->primero = nuevo;
        this->ultimo = nuevo;
    }

    else
    {
        nuevo->cont = this->ultimo->cont + 1;
        this->ultimo->siguiente = nuevo;
        nuevo->anterior = this->ultimo;
        this->ultimo = nuevo;
    }
}

//eliminar elementos de la pista
avion *pista::pop()
{
    if(this->primero != nullptr)
    {
        avion *ret = this->primero;
        this->primero = ret->siguiente;
        //if(this->primero != nullptr) this->primero->anterior = nullptr;
        return ret;
    }
    else return nullptr;
}

QString pista::salidaconsola()
{
    QString salida = "--------------Pista--------------\n";
    if(this->ultimo != nullptr)
    {
        salida += "LLegada del avión No. " + QString::number(this->ultimo->cont) + "\n";
    }
    if(this->primero != nullptr)
    {
        salida += "Avión desabordando: Avión No. " + QString::number(this->primero->cont) + "\n";
        salida += "Cantidad de pasajeros: " + QString::number(this->primero->pasajero) + "\n";
        salida += "Turnos restantes: " + QString::number(this->primero->desabordaje) + "\n";
    }
    salida += "---------------------------------------------------\n";
    return salida;
}
