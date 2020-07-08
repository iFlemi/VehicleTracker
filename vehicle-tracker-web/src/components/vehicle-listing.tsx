import React, {FunctionComponent, useState, useEffect} from 'react' 
import VehicleAdapter from '../adapters/VehicleServiceAdapater'
import { Vehicle } from '../models/Vehicle'
import {Vector} from 'prelude-ts'
import VehicleModal from './vehicle-modal'
import AddVehicleForm from './add-vehicle-form'

const VehicleListing:FunctionComponent = () => {    
    const [vehicles, setVehicles] = useState(Vector.empty<Vehicle>())
    
    useEffect(() => {
        const load = async () => {
            const vehicleResponses = await VehicleAdapter.getVehicles()
            setVehicles(vehicleResponses)
        }
        load()
    }, []);

    const deleteButtonClick = async (guid:string) => {
        console.log("deleting GUID:", guid)
        await VehicleAdapter.deleteVehicle(guid)
        const updatedVehicles = vehicles.removeFirst(v => v.guid === guid)
        setVehicles(updatedVehicles)
    }

    const updateVehicleList = (vehicle:Vehicle) =>{
        const updatedVehicles = vehicles.append(vehicle)
        setVehicles(updatedVehicles)
    }

    return (
    <div>
        <AddVehicleForm updateVehicleList = {updateVehicleList}></AddVehicleForm>
        <ul>{vehicles.map(v => 
            <li key={v.guid}>{v.registration} <button onClick={() => deleteButtonClick(v.guid)}>DELETE</button></li>)}
        </ul>
    </div>)
}

export default VehicleListing