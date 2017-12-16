#include "colapasajeros.h"

colapasajeros::colapasajeros()
{
    this->primero = nullptr;
    this->ultimo = nullptr;
    this->cont = 0;
}

void colapasajeros::push(pasajero *pasajero_)
{
    if(pasajero_ != nullptr)
    {
        if(this->cont < 10)
        {
            if(this->ultimo == nullptr)
            {
                this->primero = pasajero_;
                this->ultimo = pasajero_;
                pasajero_->siguiente = nullptr;
            }
            else
            {
                this->ultimo->siguiente = pasajero_;
                pasajero_->siguiente = nullptr;
                this->ultimo = pasajero_;
            }
            this->cont++;
        }
    }
}

void colapasajeros::pop(equipaje *equipaje_)
{
    if(this->primero != nullptr)
    {
        //eliminar equipaje
        for(int i=0;i<this->primero->maletas;i++)
            equipaje_->pop();
        this->primero = this->primero->siguiente;
    }
    this->cont--;
}
