using System;

public class usuario
{
    private String nick;
    private String pass;

    public usuario raiz;
    public usuario izq;
    public usuario der;

    public usuario(String nick_, String pass_)
    {
        nick = nick_;
        pass = pass_;
        raiz = null;
        izq = null;
        der = null;
    }

    public void setnick(String nick_) { nick = nick_; }

    public String getnick() { return nick; }

    public void setpass(String pass_) { pass = pass_; }
}

class binario
{
    public usuario raiz;

    public binario()
    {
        raiz = null;
    }

    public void insertar(String nick_, String pass_, usuario r)
    {
        //insertar desde la raiz
        if (r == null)
        {
            //insertar en la raiz
            if (raiz == null) raiz = new usuario(nick_, pass_);
            else insertar(nick_, pass_, raiz);
        }
        else
        {
            //el nodo va al hijo izquierdo
            if (String.Compare(r.getnick(),nick_) > 0)
            {
                //insertar si el nodo es nulo
                if (r.izq == null) r.izq = new usuario(nick_, pass_);
                //insertar en el arbol izquierdo
                else insertar(nick_, pass_, r.izq);
            }
            //el nodo va al hijo derecho
            else if (com.compare(raiz.getnick(), nuevo.getnick()) < 0)
            {
                //insertar si el nodo es nulo
                if (r.der == null) r.der = new usuario(nick_, pass_);
                //insertar en el arbol izquierdo
                else insertar(nick_, pass_, r.der);
            }
        }
    }
}