import React, { FunctionComponent, Props, useReducer, FormEvent, ChangeEvent } from 'react'
import {Modal, ModalBody, Button, Form} from 'react-bootstrap'
import ModalHeader from 'react-bootstrap/esm/ModalHeader'
import { Vehicle } from '../models/Vehicle'
import VehicleServiceAdapter from '../adapters/VehicleServiceAdapater'

interface ModalProps {
    showModal:boolean,
    updateVehicleList: (vehicle:Vehicle) => void,
    handleClose: () => void
};

interface FormState {
    rego:string,
    make:string,
    model:string,
    year:number
}

const initialFormState:FormState = {
    rego: "",
    make: "",
    model: "",
    year: 0,
}
const SetRegoAction = "SetRegoAction"
const SetMakeAction = "SetMakeAction"
const SetModelAction = "SetModelAction"
const SetYearAction = "SetYearAction"

type FormActions = SetRego | SetMake | SetModel | SetYear

interface SetRego {
    kind: typeof SetRegoAction,
    rego: string
}
interface SetMake {
    kind: typeof SetMakeAction,
    make: string
}
interface SetModel {
    kind: typeof SetModelAction,
    model: string
}
interface SetYear {
    kind: typeof SetYearAction,
    year: number
}

const setRego = (rego:string):FormActions => {
    return {
        kind:SetRegoAction,
        rego}
}

const setMake = (make:string):FormActions => {
    return {
        kind:SetMakeAction,
        make}
}
const setModel = (model:string):FormActions => {
    return {
        kind:SetModelAction,
        model}
}
const setYear = (year:number):FormActions => {
    return {
        kind:SetYearAction,
        year}
}

const reducer = (state:FormState, action:FormActions):FormState => {
    switch(action.kind){
        case SetRegoAction:
            return {...state, rego:action.rego}
        case SetMakeAction:
            return {...state, make:action.make}
        case SetModelAction:
            return {...state, model:action.model}
        case SetYearAction:
            return {...state, year:action.year}
    }
}

const AddVehicleModal:FunctionComponent<ModalProps> = (props) => {

    const [formState, setFormState] = useReducer(reducer, initialFormState);

    const handleSubmit = async () => {
        const vehicle:Vehicle = {
            guid: "",
            registration: formState.rego,
            make: formState.make,
            model: formState.model,
            year: formState.year
        }
        const response = await VehicleServiceAdapter.createVehicle(vehicle)
        props.updateVehicleList(response)
        props.handleClose()
    }

    const onRegoChange = (e: ChangeEvent<HTMLInputElement>) => {
        setFormState(setRego(e.target.value));
    };
    const onMakeChange = (e: ChangeEvent<HTMLInputElement>) => {
        setFormState(setMake(e.target.value));
    };
    const onModelChange = (e: ChangeEvent<HTMLInputElement>) => {
        setFormState(setModel(e.target.value));
    };
    const onYearChange = (e: ChangeEvent<HTMLInputElement>) => {
        setFormState(setYear(e.target.valueAsNumber));
    };

    return (<Modal 
        show={props.showModal} 
        onHide={props.handleClose} centered>
        <ModalHeader closeButton>
            <Modal.Title>Add Vehicle</Modal.Title>
        </ModalHeader>
        <ModalBody>
            <Form onSubmit={() => handleSubmit()}>
                <label>Rego</label>
                <input 
                    type="text" 
                    name="rego"
                    placeholder="ABC123"
                    maxLength={6}
                    onChange={e => onRegoChange(e)}/>
                <label>Make</label>
                <input 
                    type="text" 
                    name="make"
                    placeholder="Tesla"
                    maxLength={40}
                    onChange={e => onMakeChange(e)}/>
                <label>Model</label>
                <input 
                    type="text" 
                    name="model"
                    placeholder="Model 3"
                    maxLength={40}
                    onChange={e => onModelChange(e)}/>
                <label>Year</label>
                <input 
                    type="number" 
                    name="year"
                    maxLength={4}
                    onChange={e => onYearChange(e)}/>
            </Form>
        </ModalBody>
        <Modal.Footer>
          <Button variant="secondary" onClick={props.handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={() => handleSubmit()}>
            Save Changes
          </Button>
        </Modal.Footer>
    </Modal>)
}
export default AddVehicleModal

