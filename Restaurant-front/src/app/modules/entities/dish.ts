import {BaseEntity} from './common/base-entity';
import {Restaurant} from './restaurant';

export interface Dish extends BaseEntity{
  name : string;
  price : number;
  restaurant : Restaurant;
  restaurantId : number;
}
