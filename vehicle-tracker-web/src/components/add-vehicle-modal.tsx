import React, { FunctionComponent, Props, useReducer, FormEvent, ChangeEvent } from 'react'
import {Modal, ModalBody, Button} from 'react-bootstrap'
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

const AddVehicleModal:FunctionComponent<ModalProps> = (props) => {

    const [formState, setFormState] = useReducer(reducer, initialFormState);

    const handleSubmit = async () => {
        const response = await VehicleServiceAdapter.createVehicle(formState.rego)
        props.updateVehicleList(response)
        props.handleClose()
    }

    const onRegoChange = (e: ChangeEvent<HTMLInputElement>) => {
        setFormState(setRego(e.target.value));
    };

    return (<Modal 
        show={props.showModal} 
        onHide={props.handleClose} centered>
        <ModalHeader closeButton>
            <Modal.Title>Add Vehicle</Modal.Title>
        </ModalHeader>
        <ModalBody>
            <form onSubmit={() => handleSubmit()}>
                <label>Rego</label>
                <input 
                    type="text" 
                    name="rego"
                    placeholder="ABC123"
                    maxLength={6}
                    onChange={e => onRegoChange(e)}/>
            </form>
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

