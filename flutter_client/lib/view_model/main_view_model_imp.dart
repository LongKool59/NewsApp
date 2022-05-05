import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_client/model/login_result_model.dart';
import 'package:flutter_client/model/login_model.dart';
import 'package:flutter_client/network/login.dart';
import 'package:flutter_client/state/state.dart';
import 'package:flutter_client/view_model/main_view_model.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';

class MainViewModelImp implements MainViewModel {
  @override
  void changeLoading(BuildContext context) {
    context.read(isLoading).state = !context.read(isLoading).state;
  }

  @override
  Future<bool> checkToken(BuildContext context) async {
    var secure = const FlutterSecureStorage();
    var token = await secure.read(key: 'TOKEN');
    if (token != null && token.isNotEmpty) {
      context.read(bearerToken).state = token;
      Navigator.of(context).pushNamedAndRemoveUntil('/home', (route) => false);
      return true;
    }
    return false;
  }

  @override
  Future<LoginResultModel> processLogin(
      BuildContext context, LoginModel loginModel) async {
    context.read(isLoading).state = false;
    var result = await login(loginModel);
    context.read(isLoading).state = true;
    return result;
  }

  @override
  Future<void> setToken(BuildContext context, String token) async {
    var secure = FlutterSecureStorage();
    await secure.write(key: 'TOKEN', value: token);
    context.read(bearerToken).state = token;
  }
}
