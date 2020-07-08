import { Vehicle } from '../models/Vehicle'
import axios from 'axios'
import {Vector} from 'prelude-ts'

const localUrl = "https://localhost:44380/vehicle/"


const VehicleServiceAdapter = { 
  getVehicles: async () => {
    try {
      const response = await axios.get<Vehicle[]>(`${localUrl}getAllVehicles`)
      console.log("Vehicles from DB:", response.data)
      return Vector.ofIterable(response.data);
    } catch (error) {
      console.error(error)
      throw new Error(error)
    }
  },

  deleteVehicle: async(guid:string) => {
  try {
    const response = await axios.delete(`${localUrl}deleteVehicle?guid=${guid}`)
    console.log(`Delete ${guid} Response`, response)
  } catch (error) {
    console.error(error)
    throw new Error(error)
   }
  },

  createVehicle: async(rego:string) => {
    try {
      const response = await axios.post<Vehicle>(
        `${localUrl}createVehicle`,
        {
          registration: rego,
        }
      );
      return response.data
    } catch(error){
      console.error(error)
      throw new Error(error)
    }
  },

  updateVehicle: async(vehicle:Vehicle) => {
    try {
      const response = await axios.put<Vehicle>(
        `${localUrl}updateVehicle`,
        vehicle,
      );
      return response.data
    } catch(error){
      console.error(error)
      throw new Error(error)
    }
  }
}

export default VehicleServiceAdapter