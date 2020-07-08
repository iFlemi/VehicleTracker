import { TemperatureSensor } from '../models/TemperatureSensor'
import axios from 'axios'
import {Vector} from 'prelude-ts'

//const localUrl = "https://localhost:44380/temperatureSensor/"
const localUrl = "https://vehicletracker.azurewebsites.net/temperatureSensor/"

const TemperatureSensorServiceAdapter = { 
  getTemperatureForVehicle: async (guid:string) => {
    try {
      const response = await axios.get<TemperatureSensor>(`${localUrl}getTemperatureForVehicle?vehicleGuid=${guid}`)
      return response.data;
    } catch (error) {
      console.error(error)
      throw new Error(error)
    }
  },

  getTemperaturesForVehicles: async (vehicleGuilds:string[]) => {
    try {
      const response = await axios.post<TemperatureSensor[]>(`${localUrl}getTemperaturesForVehicles`, 
      {
        vehicleGuids: vehicleGuilds
      })
      return Vector.ofIterable(response.data);
    } catch (error) {
      console.error(error)
      throw new Error(error)
    }
  }
}

export default TemperatureSensorServiceAdapter