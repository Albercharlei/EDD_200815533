#ifndef COLAPASAJEROS_H
#define COLAPASAJEROS_H

#include <pasajero.h>
#include <equipaje.h>

typedef struct colapasajeros colapasajeros;

struct colapasajeros
{
    int cont;
    pasajero *primero;
    pasajero *ultimo;

    colapasajeros();
    void push(pasajero *pasajero_);
    void pop(equipaje *equipaje_);
};

#endif // COLAPASAJEROS_H
