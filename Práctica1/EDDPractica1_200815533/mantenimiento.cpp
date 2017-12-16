#include "mantenimiento.h"

estacion::estacion(int cont_)
{
    this->cola = new colaestacion();
    this->id = cont_;
    this->siguiente = nullptr;
}

mantenimiento::mantenimiento()
{
    this->cont = 1;
    this->primero = nullptr;
    this->ultimo = nullptr;
    this->actual = nullptr;
}

void mantenimiento::push()
{
    estacion *nuevo = new estacion(this->cont);
    if(this->primero == nullptr)
    {
        this->primero = nuevo;
        this->ultimo = nuevo;
    }
    else
    {
        this->ultimo->siguiente = nuevo;
        this->ultimo = nuevo;
    }
    this->cont++;
}

estacion *mantenimiento::getestacion()
{
    if(this->actual == nullptr) this->actual = this->primero;
    estacion *ret = this->actual;
    this->actual = this->actual->siguiente;
    return ret;
}

void mantenimiento::eliminaraviones()
{
    estacion *temp = this->primero;
    while(temp != nullptr)
    {
        if(temp->cola->primero != nullptr)
        {
            if(temp->cola->primero->mantenimiento != 0) temp->cola->primero->mantenimiento--;
            else temp->cola->pop();
        }
        temp = temp->siguiente;
    }
}

colaestacion::colaestacion()
{
    this->primero = nullptr;
    this->ultimo = nullptr;
}

void colaestacion::push(avion *avion_)
{
    avion_->siguiente = nullptr;
    avion_->anterior = nullptr;
    if(this->primero == nullptr)
    {
        this->primero = avion_;
        this->ultimo = avion_;
    }
    else
    {
        this->ultimo->siguiente = avion_;
        this->ultimo = avion_;
    }
}

void colaestacion::pop()
{
    avion *temp = this->primero;
    if(temp != nullptr) this->primero = this->primero->siguiente;
}

QString mantenimiento::salidaconsola()
{
    QString salida = "--------------Estaciones de mantenimiento--------------\n";
    estacion *temp = this->primero;
    while(temp != nullptr)
    {
        salida += "*Estación " + QString::number(temp->id) + "\n";
        if(temp->cola->primero == nullptr) salida += "\tAvión en mantenimiento: ninguno\n\tTurnos restantes: 0\n";
        else salida += "\tAvión en mantenimiento: Avión " + QString::number(temp->cola->primero->cont) + "\n\tTurnos restantes: " + QString::number(temp->cola->primero->mantenimiento) + "\n";
        temp = temp->siguiente;
    }

    salida += "---------------------------------------------------\n";
    return salida;
}
