import React, { Fragment, useEffect, useState } from "react";
import axios from "axios";
import { Activity } from "../models/activity";
import Navbar from "./Navbar";
import ActivityDashboard from "../../features/activities/dashboard/activityDashboard";
import { Container, Header, List, ListItem } from "semantic-ui-react";

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios
      .get<Activity[]>("http://localhost:5000/api/activities")
      .then((Response) => {
        console.log(Response);
        setActivities(Response.data);
      });
  }, []);

  return (
    <Fragment>
      <Navbar></Navbar>
      <Container style={{ marginTop: "7em" }}>
        <ActivityDashboard activities={activities} />
      </Container>
    </Fragment>

    /* <Fragment>
      <Navbar></Navbar>
      <ActivityDashboard activities={activities} />
    </Fragment> */
  );
}

export default App;
