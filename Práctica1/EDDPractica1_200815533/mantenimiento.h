#ifndef MANTENIMIENTO_H
#define MANTENIMIENTO_H
#include <avion.h>

typedef struct estacion estacion;
typedef struct mantenimiento mantenimiento;
typedef struct colaestacion colaestacion;

struct estacion
{
    int id;
    estacion *siguiente;
    colaestacion *cola;
    estacion(int cont_);
};

struct mantenimiento
{
    estacion *primero;
    estacion *ultimo;
    estacion *actual;
    int cont;

    void push();
    void push(avion *avion_);
    void eliminaraviones();
    estacion *getestacion();
    mantenimiento();
    QString salidaconsola();
};

struct colaestacion
{
    avion *primero;
    avion *ultimo;

    void push(avion *avion_);
    void pop();
    colaestacion();
};

#endif // MANTENIMIENTO_H
