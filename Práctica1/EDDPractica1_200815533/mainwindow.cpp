#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    this->mainpista = new pista();
    this->maindesabordaje = new desabordaje();
    this->mainescritorios = new escritorios();
    this->mainequipaje = new equipaje();
    this->mainmantenimiento = new mantenimiento();
    //insertar 4 escritorios
    this->mainescritorios->insertarescritorio("A");
    this->mainescritorios->insertarescritorio("C");
    this->mainescritorios->insertarescritorio("D");
    this->mainescritorios->insertarescritorio("B");
    //insertar 3 estaciones
    this->mainmantenimiento->push();
    this->mainmantenimiento->push();
    this->mainmantenimiento->push();
    this->textoconsola = "";
    this->turno = 1;
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    system("rm /Volumes/Macintosh\\ HD/Users/pista.dot");
    delete ui;
}
//botón de acción
void MainWindow::on_pushButton_clicked()
{
    textoconsola += "***********Inicia turno " + QString::number(turno) + "***********\n";
    //insertar los pasajeros de la cola de desabordaje
    if(this->maindesabordaje->primero != nullptr)
    {
        escritorio *in = this->mainescritorios->getcola();
        while(in != nullptr)
        {
            pasajero *temp = this->maindesabordaje->pop();
            if(temp == nullptr) break;
            //insertar pasajero
            in->insertarpasajero(temp);
            //insertar maletas
            for(int i=0;i<temp->maletas;i++) this->mainequipaje->push();
            //obtener siguiente espacio en la cola
            in = this->mainescritorios->getcola();
        }
    }
    //eliminar pasajeros que ya no tengan turnos
    this->mainescritorios->eliminarpasajeros(this->mainequipaje);//eliminar pasajeros si no tienen turnos
    //insertar la cantidad de pasajeros de un avión cuando haya terminado
    if(this->mainpista->primero != nullptr)
    {
        if(this->mainpista->primero->desabordado == 1)
        {
            for(int i = 0;i<this->mainpista->primero->pasajero;i++) this->maindesabordaje->push();
            this->mainpista->primero->desabordado = 0;
        }

    }
    //insertar avión
    this->mainpista->push();
    textoconsola += this->mainpista->salidaconsola();
    textoconsola += this->mainescritorios->salidaconsola();
    //eliminar el primer avión si se terminaron sus turnos de desbordaje
    if(this->mainpista->primero->desabordaje == 0)
    {
        avion *out = this->mainpista->pop();
        estacion *in = this->mainmantenimiento->getestacion();
        in->cola->push(out);
    }
    else this->mainpista->primero->desabordaje--;
    //eliminar aviones de la estacion
    textoconsola += this->mainmantenimiento->salidaconsola();
    textoconsola += this->mainequipaje->salidaconsola();
    this->mainmantenimiento->eliminaraviones();
    graficador *graph = new graficador();
    graph->graficar(mainpista,maindesabordaje,mainescritorios,mainequipaje,mainmantenimiento);
    textoconsola += "***********Finaliza turno " + QString::number(turno) + "***********\n\n";
    turno++;
    ui->consola->setText(textoconsola);
}
