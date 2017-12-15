#ifndef GRAFICADOR_H
#define GRAFICADOR_H

#include <QString>
#include <avion.h>
#include <pasajero.h>
#include <escritorios.h>
#include <colapasajeros.h>
#include <piladocumentos.h>

class graficador
{
public:
    graficador();

    QString graficar(pista *pista_,desabordaje *desabordaje_,escritorios *escritorios_);

    QString graficarpista(pista *pista_);//método para graficar la pista
    QString graficardesabordaje(desabordaje *desabordaje_);//método para graficar el desabordaje
    QString graficarescritorios(escritorios *escritorios_);//método para graficar los escritorios
    QString graficarpasajeros(colapasajeros *cola_,escritorio *escritorio_);//método para graficar los pasajeros en los escritorios
    QString graficardocumentos(piladocumentos *pila_,escritorio *escritorio_);//método para graficar la pila de los documentos
};

#endif // GRAFICADOR_H
