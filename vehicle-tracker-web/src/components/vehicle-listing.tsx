import React, {FunctionComponent, useState, useEffect} from 'react' 
import VehicleAdapter from '../adapters/VehicleServiceAdapater'
import { Vehicle } from '../models/Vehicle'
import {Vector, Option} from 'prelude-ts'
import AddVehicleModal from './add-vehicle-modal'
import {Button, Table} from 'react-bootstrap'
import UpdateVehicleModal from './update-vehicle-modal'
import { prependOnceListener } from 'process'

const VehicleListing:FunctionComponent = () => {    
    const [vehicles, setVehicles] = useState(Vector.empty<Vehicle>())
    const [showModal, setShowModal] = useState(false)
    const [vehicleToUpdate, setVehicleToUpdate] = useState(Option.none<Vehicle>());

    useEffect(() => {
        const load = async () => {
            const vehicleResponses = await VehicleAdapter.getVehicles()
            setVehicles(vehicleResponses)
        }
        load()
    }, []);

    const deleteButtonClick = async (guid:string) => {
        await VehicleAdapter.deleteVehicle(guid)
        const updatedVehicles = vehicles.removeFirst(v => v.guid === guid)
        setVehicles(updatedVehicles)
    }

    const updateButtonClick = async (vehicle:Vehicle) => {
        setVehicleToUpdate(Option.some(vehicle))
    }

    const displayAddedVehicle = (vehicle:Vehicle) =>{
        const updatedVehicles = vehicles.append(vehicle)
        setVehicles(updatedVehicles)
    }

    const displayUpdatedVehicles = (vehicle:Vehicle) =>{
        const updatedVehicles = vehicles
            .removeFirst(v => v.guid === vehicle.guid)
            .append(vehicle)
        setVehicles(updatedVehicles)
    }

    const handleOpen = () => { setShowModal(true) }
    const handleClose = () => { setShowModal(false) }

    return (
    <div>
        <AddVehicleModal 
            showModal={showModal}
            updateVehicleList={displayAddedVehicle}
            handleClose={handleClose}
            />
        {vehicleToUpdate.map(v => <UpdateVehicleModal
            showModal={vehicleToUpdate.isSome()}
            updateVehicleList={displayUpdatedVehicles}
            handleClose={() => setVehicleToUpdate(Option.none())}
            vehicleToUpdate={v}
        /> ).getOrCall(() => <></>)}

        <h3>Vehicles</h3>
        <Table hover>
            <thead>
                <tr>
                    <th>Guid</th>
                    <th>Registration</th>
                    <th>Make</th>
                    <th>Model</th>
                    <th>Year</th>
                    <th>Update</th>
                    <th>Delete</th>
                </tr>
            </thead>
            <tbody>
                {vehicles.map(v => 
                <tr> 
                    <td>{v.guid}</td>
                    <td>{v.registration}</td>
                    <td>{v.make}</td>
                    <td>{v.model}</td> 
                    <td>{v.year}</td>
                    <td><Button size="sm" onClick={() => updateButtonClick(v)}>UPDATE</Button></td>
                    <td><Button size="sm" variant="danger" onClick={() => deleteButtonClick(v.guid)}>DELETE</Button></td>
                </tr>
                )}
            </tbody>
        </Table>
        <Button onClick={() => handleOpen()}>ADD VEHICLE</Button>

    </div>)
}

export default VehicleListing