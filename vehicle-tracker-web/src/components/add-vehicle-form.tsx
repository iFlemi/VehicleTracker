import React, { FunctionComponent, Props, useState, FormEvent, ChangeEvent, useReducer } from 'react'
import { Vehicle } from '../models/Vehicle'
import { Vector } from 'prelude-ts';
import VehicleServiceAdapter from '../adapters/VehicleServiceAdapater';

interface AddVehicleFormProps {
    updateVehicleList: (vehicle:Vehicle) => void
};

interface FormState {
    rego:string,
}

const initialFormState:FormState = {
    rego: ""
}
const SetRegoAction = "SetRegoAction"

type FormActions = SetRego //| New Action 1 | New Action 2

interface SetRego {
    kind: typeof SetRegoAction,
    rego: string
}

const setRego = (rego:string):FormActions => {
    return {
        kind:SetRegoAction,
        rego}
}

const reducer = (state:FormState, action:FormActions):FormState => {
    switch(action.kind){
        case SetRegoAction:
            return {...state, rego:action.rego}
    }
}

const AddVehicleForm:FunctionComponent<AddVehicleFormProps> = (props) => {
    const [formState, setFormState] = useReducer(reducer, initialFormState);

    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const response = await VehicleServiceAdapter.createVehicle(formState.rego)
        props.updateVehicleList(response)
    }

    const onRegoChange = (e: ChangeEvent<HTMLInputElement>) => {
        setFormState(setRego(e.target.value));
    };

    return (
      <form onSubmit={(e) => handleSubmit(e)}>
        <label>Rego</label>
        <input 
            type="text" 
            name="rego"
            placeholder="ABC123"
            maxLength={6}
            onChange={e => onRegoChange(e)}/>
        <input type="submit" value="SUBMIT"/>
      </form>)
}
export default AddVehicleForm

