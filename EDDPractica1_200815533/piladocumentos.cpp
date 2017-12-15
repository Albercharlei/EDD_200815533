#include "piladocumentos.h"

documento::documento(int cont)
{
    this->anterior = nullptr;
    this->siguiente = nullptr;
    this->id = "Doc" + QString::number(cont);
}

piladocumentos::piladocumentos()
{
    this->tope = nullptr;
    this->cont = 0;
}

void piladocumentos::push()
{
    documento *nuevo = new documento(this->cont);
    if(this->tope == nullptr) this->tope = nuevo;
    else
    {
        this->tope->siguiente = nuevo;
        nuevo->anterior = this->tope;
        this->tope = nuevo;
    }
    this->cont++;
}

void piladocumentos::vaciar()
{
    this->tope = nullptr;
    this->cont = 0;
}
