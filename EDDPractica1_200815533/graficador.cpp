#include "graficador.h"

#include <avion.h>

#include <QFile>
#include <QTextStream>

graficador::graficador()
{

}

QString graficador::graficar(pista *pista_,desabordaje *desabordaje_)
{
    QString salida = "digraph G{\n";
    //agregar subgrafo de la pista
    salida += graficarpista(pista_);
    //agregar subgrafo del desabordaje
    salida += graficardesabordaje(desabordaje_);
    //finalizar grafo
    salida += "}\n";
    //generar grafo
    QFile archivo("/Volumes/Macintosh HD/Users/charlei/Desktop/pista.dot");
        if(archivo.open(QFile::WriteOnly)){
            QTextStream st(&archivo);
            st << salida;
        }
    archivo.close();
    return salida;
}

QString graficador::graficarpista(pista *pista_)
{
    QString salida = "";
    //iniciar sugrafo de la pista de aviones
    salida += "subgraph Pista{\ngraph[color=black, label=\"Pista\"];\n";
    salida += "node[shape=ellipse, color=black];\nrankdir=UD;\n";

    avion *temp = pista_->primero;
    //agregar identificadores
    while(temp != nullptr)
    {
        salida += "A" + QString::number(temp->cont) + " [label=\"Avión: " + QString::number(temp->cont) + "\nTipo: " + temp->tipostring + "\nPasajeros: " + QString::number(temp->pasajero) + "\"];\n";
        temp = temp->siguiente;
    }
    //agregar apuntadores
    temp = pista_->primero;
    while(temp->siguiente != nullptr)
    {
        salida += "A" + QString::number(temp->cont) + "->" + "A" + QString::number(temp->siguiente->cont) + ";\n";
        salida += "A" + QString::number(temp->siguiente->cont) + "->" + "A" + QString::number(temp->cont) + ";\n";
        temp = temp->siguiente;
    }
    //finalizar subgrafo de la pista
    salida += "}\n";

    return salida;
}

QString graficador::graficardesabordaje(desabordaje *desabordaje_)
{
    QString salida = "";
    //iniciar sugrafo de la pista de aviones
    salida += "subgraph Desabordaje{\ngraph[color=black, label=\"Desabordaje\"];\n";
    salida += "node[shape=ellipse, color=black];\nrankdir=UD;\n";

    pasajero *temp = desabordaje_->primero;
    //agregar identificadores
    while(temp != nullptr)
    {
        salida += "P" + QString::number(temp->id) + " [label=\"ID: " + QString::number(temp->id) + "\nMaletas: " + QString::number(temp->maletas) + "\nDocumentos: " + QString::number(temp->documentos) + "\"];\n";
        temp = temp->siguiente;
    }
    //agregar apuntadores
    temp = desabordaje_->primero;
    while(temp->siguiente != nullptr)
    {
        salida += "P" + QString::number(temp->id) + "->" + "P" + QString::number(temp->siguiente->id) + ";\n";
        temp = temp->siguiente;
    }
    //finalizar subgrafo de la pista
    salida += "}\n";

    return salida;
}
