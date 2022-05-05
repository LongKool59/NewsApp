import 'dart:convert';
import 'package:dio/dio.dart';
import 'package:flutter_client/model/login_model.dart';
import 'package:flutter_client/model/login_result_model.dart';
import 'api.dart';

Future<LoginResultModel> login(LoginModel login) async {
  var dataSubmit = {'Email': login.email, 'Password': login.password};
  var result = await Dio().post('$mainAPI$loginAPI',
      options: Options(
        headers: {
          Headers.contentTypeHeader: "application/json",
          Headers.acceptHeader: "application/json"
        },
        followRedirects: false,
        validateStatus: (status) => status! < 500,
      ),
      data: jsonEncode(dataSubmit));
  if (result.statusCode == 401) {
    return LoginResultModel(401, 'Login failed! Please check user/password');
  } else {
    return LoginResultModel(result.statusCode!.toInt(), result.data.toString());
  }
}
