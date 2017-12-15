#ifndef COLAPASAJEROS_H
#define COLAPASAJEROS_H

#include <pasajero.h>

typedef struct colapasajeros colapasajeros;

struct colapasajeros
{
    int cont;
    pasajero *primero;
    pasajero *ultimo;

    colapasajeros();
    void push(pasajero *pasajero_);
    void pop();
};

#endif // COLAPASAJEROS_H
