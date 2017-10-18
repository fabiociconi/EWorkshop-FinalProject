import * as webpack from "webpack";
import PathHelper from "./webpack.helper";

let LiveReloadPlugin = require("webpack-livereload-plugin");

const DevelopmentConfig: webpack.Configuration = {
    cache: true,
    devtool: "source-map",
    performance: {
        hints: false		
    },
    entry: {
        "main": PathHelper.GetPath(["app", "main.ts"])
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: [
                    "awesome-typescript-loader",
                    "angular-router-loader",
                    "angular2-template-loader",
                    "source-map-loader",
                    "tslint-loader"
                ]
            },
        ]
    },
    plugins: [
        new webpack.DllReferencePlugin({
            context: process.cwd(),
            manifest: require(PathHelper.GetPath(["wwwroot", "dist", "AngularStuff.json"]))
        }),
        new LiveReloadPlugin({})
    ]
};

export default DevelopmentConfig;