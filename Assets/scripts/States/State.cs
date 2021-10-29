using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface State
{
    void OnTransition(State previousState, DaleStateHandler daleStateHandler);
    State DuringState(DaleStateHandler daleStateHandler);
}
