#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <avion.h>
#include <pasajero.h>

#include <graficador.h>

#include <QMainWindow>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    pista *mainpista;
    desabordaje *maindesabordaje;
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void on_pushButton_clicked();

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
