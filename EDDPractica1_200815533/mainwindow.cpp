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
        for(int i = 0;i<this->mainpista->primero->pasajero;i++) this->maindesabordaje->push();
        this->mainpista->primero->pasajero = 0;
    }
    //insertar avión
    this->mainpista->push();
    //eliminar el primer avión si se terminaron sus turnos de desbordaje
    if(this->mainpista->primero->desabordaje == 0)
    {
        avion *out = this->mainpista->pop();
        estacion *in = this->mainmantenimiento->getestacion();
        in->cola->push(out);
    }
    else this->mainpista->primero->desabordaje--;
    //eliminar aviones de la estacion
    this->mainmantenimiento->eliminaraviones();

    graficador *graph = new graficador();
    graph->graficar(mainpista,maindesabordaje,mainescritorios,mainequipaje,mainmantenimiento);
}
