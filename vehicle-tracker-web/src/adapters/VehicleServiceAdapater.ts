import { VehicleResponse } from '../models/VehicleResponse'
import axios from 'axios'
import {Vector} from 'prelude-ts'

const localUrl = "https://localhost:44380/vehicle/"

const VehicleServiceAdapter = { getVehicles: async () => {
    try {
      const response = await axios.get<VehicleResponse[]>(`${localUrl}getAllVehicles`)
      console.log(response.data)
      return Vector.ofIterable(response.data);
    } catch (error) {
      console.error(error)
      throw new Error(error)
    }
  }
}

export default VehicleServiceAdapter