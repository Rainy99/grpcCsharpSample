const grpc  = require('grpc')

const protoPath = './sample.proto';
let loader = grpc.load(protoPath);
let sample = loader.sample;

function  run(){
    let client = new sample.UserService('localhost:8080',grpc.credentials.createInsecure());
    client.GetUser({},(err,res) => {
        if(err){
            console.error(err);
        }else{
            console.log(res);
        }
    });
}

run();