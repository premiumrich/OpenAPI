const express = require('express');
const app = express();
const port = 1055;

app.use(express.json());
app.use(express.static('static'));

require('./routes')(app);

app.listen(port, () => {
  console.log(`Trulioo JavaScript SDK sample app listening at http://localhost:${port}`);
});
