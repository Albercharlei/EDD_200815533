#ifndef GRAFICADOR_H
#define GRAFICADOR_H

#include <QString>
#include <avion.h>
#include <pasajero.h>

class graficador
{
public:
    graficador();

    QString graficar(pista *pista_,desabordaje *desabordaje_);

    QString graficarpista(pista *pista_);//método para graficar la pista
    QString graficardesabordaje(desabordaje *desabordaje_);//método para graficar el desabordaje

};

#endif // GRAFICADOR_H
