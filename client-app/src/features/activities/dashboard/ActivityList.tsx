import React from "react";
import {
  Button,
  Item,
  ItemDescription,
  ItemHeader,
  Label,
  Segment,
} from "semantic-ui-react";
import { Activity } from "../../../app/models/activity";

interface Props {
  activities: Activity[];
}

export default function ActivityList({ activities }: Props) {
  return (
    <Segment>
      <Item.Group divided>
        {activities.map((activity) => (
          <Item key={activity.id}>
            <Item.Content>
              <ItemHeader as={"a"}>{activity.title}</ItemHeader>
              <Item.Meta>{activity.date}</Item.Meta>
              <ItemDescription>
                <div>{activity.description}</div>
                <div>
                  {activity.city},{activity.venue}
                </div>
              </ItemDescription>
              <Item.Extra>
                <Button floated="right" content="view" color="blue" />
                <Label basic content={activity.category}></Label>
              </Item.Extra>
            </Item.Content>
          </Item>
        ))}
      </Item.Group>
    </Segment>
  );
}
