import React, {FunctionComponent, useState, useEffect} from 'react' 
import VehicleAdapter from '../adapters/VehicleServiceAdapater'
import { VehicleResponse } from '../models/VehicleResponse'
import {Vector} from 'prelude-ts'


const  VehicleListing:FunctionComponent = () => {    
    const [vehicles, setVehicles] = useState(Vector.empty<VehicleResponse>())
    
    useEffect(() => {
        const load = async () => {
            const vehicleResponses = await VehicleAdapter.getVehicles()
            setVehicles(vehicleResponses)
        }
        load()
    }, [])    

    return (<div>
        <ul>
            {vehicles.map(v => <li>{v.registration}</li>)}
        </ul>
    </div>)
}

export default VehicleListing