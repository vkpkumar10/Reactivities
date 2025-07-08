import { useState, useEffect } from "react";
// import reactLogo from "./assets/react.svg";
// import viteLogo from "/vite.svg";
import "./App.css";

import { List, ListItem, ListItemText, Typography } from "@mui/material";
import axios from "axios";

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    // fetch("https://localhost:5001/api/activities")
    //   .then((response) => response.json())
    //   .then((data) => setActivities(data));

    axios
      .get<Activity[]>("https://localhost:5001/api/activities")
      .then((response) => setActivities(response.data));

    return () => {
      // Cleanup function if needed
    };
  }, []);

  // const [loading, setLoading] = useState(false);

  // const [count, setCount] = useState(0);

  return (
    <>
      <Typography variant="h3">Reactivities</Typography>
      <List>
        {activities.map((activity) => (
          <ListItem key={activity.id}>
            <ListItemText primary={activity.title} />
          </ListItem>
        ))}
      </List>
    </>
  );
}

export default App;
